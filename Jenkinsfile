pipeline {
    agent any

    parameters {
        string(defaultValue: "HelloHiApi.sln", description: 'Solution file name', name: 'solutionName')
        string(defaultValue: "HelloHiApi.Test/HelloHiApi.Test.csproj", description: 'Test file name', name: 'testName')
    }
    stages {
        stage('Restore') {
            steps{

                echo 'Restoring packages'
                bat 'dotnet restore %solutionName% '
                       
            }
        }
        stage('Build'){
            steps{

                echo 'build project'
                bat 'dotnet build %solutionName% -p:Configuration=release -v:q'
            }

        }
        stage('Test'){
            steps{

                echo 'Test project'
                bat 'dotnet test  %testName% -p:Configuration=release -v:q'

                }

        }
        stage('Publish'){
            steps{
                echo 'publish project'
                bat 'dotnet publish %solutionName% -c RELEASE -o Publish'

            }

        }

        stage('deploy') {
            steps {
                        echo 'run docker'
                        bat 'docker build --tag hellohiapi -f dockerfile .'

            }
        }
        stage('tag the image') {
            steps {
                        echo 'run docker'
                        bat 'docker tag hellohiapi:latest dharna138/simple-webapi:helloapi'

            }
        }



        stage('push docker image')
        {
        	steps
        	{
        		echo 'push the image'
        		bat 'docker push dharna138/simple-webapi:helloapi'
        	}
        }

        stage('untag docker image')
        {
        	steps
        	{
        		echo 'untag the image'
        		bat 'docker rmi helloapi'
        	}
        }
        stage('pull docker image')
        {
        	steps
        	{
        		echo 'pull the image'
        		bat 'docker pull dharna138/simple-webapi:helloapi'
        	}
        }
        stage('run docker image')
        {
        	steps
        	{
        		echo 'run the image'
        		bat 'docker run -p 4000:11180 helloapi'
        	}
        }

        

        
    }
}
