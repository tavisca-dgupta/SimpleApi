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
		     string(name: 'username', defaultValue: 'dharna138')
        string(name: 'password', defaultValue: 'Qwerty@123')
        string(name: 'reponame', defaultValue: 'simple-webapi')
 		string(name: 'sonarProjectName', defaultValue: 'WebApi')

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
        stage('SonarQube'){
        	steps{
            bat '''
                        dotnet %SonarqubePath%  begin /k:"%sonarProjectName%" /d:sonar.host.url=%SonarUrl%  /d:sonar.login="%SonarToken%"
                        dotnet  build
                        dotnet %SonarqubePath% end  /d:sonar.login="%SonarToken%"
                '''  
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

        stage('Docker build') {
             steps{
			    
			    bat 'docker build -t hellohiapi -f Dockerfile .'
		}
        }
        
		stage('Login'){
            steps{
                echo 'Login into docker'
                bat 'docker login -u %username% -p %password%'
                
            }
        }
        
        stage('Tag docker image'){
            steps {
                echo 'tag docker'
                bat 'docker tag hellohiapi:latest %username%/%reponame%:api'
            }
        }
        stage('Push the image'){
            steps{
                echo 'push the image'
                bat 'docker push %username%/%reponame%:api'
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
        		bat 'docker pull %username%/%reponame%:api'
        	}
        }
	    
	    stage('run docker image')
	    {
		    steps
		    {
			    echo 'runnig the image'
			    bat 'docker run --name %DOCKER_CONTAINER_NAME% -p 4000:11180 api'
		    }
	    }      
    }
     post{
	     always{
		     deleteDir()
	  	}
	}
}
