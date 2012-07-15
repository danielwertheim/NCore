#--------------------------------------
# Dependencies
#--------------------------------------
require 'albacore'
#--------------------------------------
# Debug
#--------------------------------------
#ENV.each {|key, value| puts "#{key} = #{value}" }
#--------------------------------------
# Environment vars
#--------------------------------------
@env_solutionname = 'NCore'
@env_solutionfolderpath = "../Source"

@env_projectnameNCore = 'NCore'

@env_buildfolderpath = 'build'
@env_version = "0.30.1"
@env_buildversion = @env_version + (ENV['env_buildnumber'].to_s.empty? ? "" : ".#{ENV['env_buildnumber'].to_s}")
@env_buildconfigname = ENV['env_buildconfigname'].to_s.empty? ? "Release" : ENV['env_buildconfigname'].to_s
@env_buildname = "#{@env_solutionname}-v#{@env_buildversion}-#{@env_buildconfigname}"
#--------------------------------------
# Reusable vars
#--------------------------------------
ncoreOutputPath = "#{@env_buildfolderpath}/#{@env_projectnameNCore}"
sharedAssemblyInfoPath = "#{@env_solutionfolderpath}/SharedAssemblyInfo.cs"
#--------------------------------------
# Albacore flow controlling tasks
#--------------------------------------
task :ci => [:installNuGets, :cleanIt, :versionIt, :buildIt, :copyNCore, :testIt, :zipIt, :packIt]

task :local => [:installNuGets, :cleanIt, :versionIt, :buildIt, :copyNCore, :testIt, :zipIt, :packIt]

task :local_signed => [:installNuGets, :cleanIt, :versionIt, :signIt, :buildIt, :copyNCore, :testIt, :zipIt, :packIt]
#--------------------------------------
task :testIt => [:unittests]

task :zipIt => [:zipNCore]

task :packIt => [:packNCoreNuGet]
#--------------------------------------
# Albacore tasks
#--------------------------------------
task :installNuGets do
	FileList["#{@env_solutionfolderpath}/**/packages.config"].each { |filepath|
		sh "NuGet.exe i #{filepath} -o #{@env_solutionfolderpath}/packages"
	}
end

assemblyinfo :versionIt do |asm|
	asm.input_file = sharedAssemblyInfoPath
	asm.output_file = sharedAssemblyInfoPath
	asm.version = @env_version
	asm.file_version = @env_buildversion
end

assemblyinfo :signIt do |asm|
	asm.input_file = sharedAssemblyInfoPath
	asm.output_file = sharedAssemblyInfoPath
	asm.custom_attributes :AssemblyKeyFileAttribute => "..\\..\\#{@env_projectnameNCore}.snk"
end

task :cleanIt do
	FileUtils.rm_rf(@env_buildfolderpath)
	FileUtils.mkdir_p(@env_buildfolderpath)
end

msbuild :buildIt do |msb|
	msb.properties :configuration => @env_buildconfigname
	msb.targets :Clean, :Build
	msb.solution = "#{@env_solutionfolderpath}/#{@env_solutionname}.sln"
end

task :copyNCore do
	FileUtils.mkdir_p(ncoreOutputPath)
	FileUtils.cp_r(FileList["#{@env_solutionfolderpath}/Projects/#{@env_projectnameNCore}/bin/#{@env_buildconfigname}/**"], ncoreOutputPath)
end

nunit :unittests do |nunit|
	nunit.command = "nunit-console.exe"
	nunit.options "/framework=v4.0.30319","/xml=#{@env_buildfolderpath}/NUnit-Report-#{@env_solutionname}-UnitTests.xml"
	nunit.assemblies FileList["#{@env_solutionfolderpath}/Tests/#{@env_solutionname}.**UnitTests/bin/#{@env_buildconfigname}/#{@env_solutionname}.**UnitTests.dll"]
end

zip :zipNCore do |zip|
	zip.directories_to_zip ncoreOutputPath
	zip.output_file = "#{@env_buildname}.zip"
	zip.output_path = @env_buildfolderpath
end

exec :packNCoreNuGet do |cmd|
	cmd.command = "NuGet.exe"
	cmd.parameters = "pack #{@env_projectnameNCore}.nuspec -version #{@env_version} -basepath #{ncoreOutputPath} -outputdirectory #{@env_buildfolderpath}"
end