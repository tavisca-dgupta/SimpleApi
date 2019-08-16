pipeline {
    agent any
    environment {
    registry = "dharna138/simple-webapi"
    registryCredential = 'Qwerty@123'
  }
 
		

    parameters {
        string(defaultValue: "HelloHiApi.sln", description: 'Solution file name', name: 'solutionName')
        string(defaultValue: "HelloHiApi.Test/HelloHiApi.Test.csproj", description: 'Test file name', name: 'testName')
			string(name: 'DOCKER_FILE',
			       defaultValue: 'simpleapi')
		    string(name: 'DOCKER_CONTAINER_NAME',
			       defaultValue: 'simpleapi-container')
		     string(name: 'USERNAME', defaultValue: 'dharna138')
        string(name: 'PASSWORD', defaultValue: 'Qwerty@123')
                string(name: 'docker-hub-credentials', defaultValue: 'localhost:8080')


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

        stage('docker build') {
             steps{
			    
			    bat 'docker build -t hellohiapi -f Dockerfile .'
			 }
        }
        stage('tag the image') {
            steps {
                        echo 'tag docker'
                        bat 'docker tag hellohiapi:latest dharna138/simple-webapi:latest'

            }
        }

stage('Upload'){
            steps{
                echo 'Login into docker'
                bat 'docker login -u dharna138 -p Qwerty@123'
                
            }
        }


        
        stage('Tag docker image'){
            steps {
                echo 'tag docker'
                bat 'docker tag hellohiapi:latest dharna138/simple-webapi:latest'
            }
        }
        stage('Push the image'){
            steps{
                echo 'push the image'
                bat 'docker push dharna138/simple-webapi:latest'
            }
        }

        stage('untag docker image')
        {
        	steps
        	{
        		echo 'untag the image'
        		bat 'docker rmi hellohiapi'
        	}
        }
        stage('pull docker image')
        {
        	steps
        	{
        		echo 'pull the image'
        		bat 'docker pull dharna138/simple-webapi:latest'
        	}
        }
        stage('run docker image')
        {
        	steps
        	{
        		echo 'run the image'
        		bat 'docker run -p 4000:11180 api'
        	}
        }

       

        
    }
     post{
	  		always{
	    		  deleteDir()
	  		}
		}
}
