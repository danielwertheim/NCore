#--------------------------------------
# Dependencies
#--------------------------------------
require 'albacore'
#--------------------------------------
# Debug
#--------------------------------------
#ENV.each {|key, value| puts "#{key} = #{value}" }
#--------------------------------------
# My environment vars
#--------------------------------------
@env_projectname = ENV['env_projectname']
@env_buildconfigname = ENV['env_buildconfigname']
@env_buildversion = ENV['env_buildversion']
@env_projectfullname = ENV['env_projectfullname']
@env_buildfolderpath = ENV['env_buildfolderpath']
@env_unitTestXmlResultsPath = ENV['env_unitTestXmlResultsPath']
@env_nugetPublishApiKey = ENV['env_nugetPublishApiKey']
@env_nugetPublishUrl = ENV['env_nugetPublishUrl']
@env_nugetSourceUrl = ENV['env_nugetSourceUrl']
@env_solutionfolderpath = "../Solution/"
#--------------------------------------
# Albacore flow controlling tasks
#--------------------------------------
desc "Fixes version, compiles the solution, executes tests and deploys."
task :default => [:buildIt, :testIt, :deployIt]

desc "Fixes version and compiles."
task :buildIt => [:versionIt, :compileIt, :copyBinaries]

desc "Executes all tests."
task :testIt => [:runUnitTests]

desc "Creates ZIP and NuGet packages."
task :deployIt => [:createZipPackage, :createNuGetPackage, :publishNuGetPackage]
#--------------------------------------
# Albacore tasks
#--------------------------------------
desc "Updates version info."
assemblyinfo :versionIt do |asm|
  sharedAssemblyInfoPath = "#{@env_solutionfolderpath}SharedAssemblyInfo.cs"
  
  asm.input_file = sharedAssemblyInfoPath
  asm.output_file = sharedAssemblyInfoPath
  asm.version = @env_buildversion
  asm.file_version = @env_buildversion  
end

desc "Creates clean build folder structure."
task :createCleanBuildFolder do
  FileUtils.rm_rf(@env_buildfolderpath)
  FileUtils.mkdir_p("#{@env_buildfolderpath}Binaries")
end

desc "Install missing NuGet packages."
exec :installNuGetPackages do |cmd|
  FileList["#{@env_solutionfolderpath}**/packages.config"].each { |filepath|
    cmd.command = "NuGet.exe"
    cmd.parameters = "i #{filepath} -o #{@env_solutionfolderpath}/packages -s #{@env_nugetSourceUrl}"
  }
end

desc "Clean and build the solution."
msbuild :compileIt => [:createCleanBuildFolder, :installNuGetPackages] do |msb|
  msb.properties :configuration => @env_buildconfigname
  msb.targets :Clean, :Build
  msb.solution = "#{@env_solutionfolderpath}#{@env_projectname}.sln"
end

desc "Copy binaries to output."
task :copyBinaries do
  FileUtils.cp_r(FileList["#{@env_solutionfolderpath}Source/#{@env_projectname}/bin/#{@env_buildconfigname}/*.*"], "#{@env_buildfolderpath}Binaries/")
end

desc "Run unit tests."
nunit :runUnitTests do |nunit|
  nunit.command = "#{@env_solutionfolderpath}packages/NUnit.2.5.10.11092/tools/nunit-console.exe"
  nunit.options "/framework=v4.0.30319","/xml=#{@env_unitTestXmlResultsPath}"
  nunit.assemblies = FileList["#{@env_solutionfolderpath}Tests/**/#{@env_buildconfigname}/*.UnitTests.dll"].exclude(/obj\//)
end

desc "Creates ZIPs package of binaries folder."
zip :createZipPackage do |zip|
     zip.directories_to_zip "#{@env_buildfolderpath}Binaries/"
     zip.output_file = "#{@env_projectfullname}.zip"
	 zip.output_path = @env_buildfolderpath
end

desc "Creates NuGet package"
exec :createNuGetPackage do |cmd|
  cmd.command = "NuGet.exe"
  cmd.parameters = "pack #{@env_projectname}.nuspec -version #{@env_buildversion} -nodefaultexcludes -outputdirectory #{@env_buildfolderpath} -basepath #{@env_buildfolderpath}Binaries"
end

desc "Publish NuGet package"
exec :publishNuGetPackage do |cmd|
  cmd.command = "NuGet.exe"
  cmd.working_directory = "#{@env_buildfolderpath}"
  cmd.parameters = "push #{@env_projectname}.#{@env_buildversion}.nupkg #{@env_nugetPublishApiKey} -src #{@env_nugetPublishUrl}"
end