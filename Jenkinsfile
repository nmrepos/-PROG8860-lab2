pipeline {
    agent any
    environment {
        DOTNET_ROOT = "${env.WORKSPACE}\\dotnet"
        PATH = "${env.WORKSPACE}\\dotnet;${env.WORKSPACE}\\dotnet\\tools;${env.PATH}"
    }
    stages {
        stage('Install .NET SDK') {
            steps {
                bat '''
                    if exist dotnet rmdir /s /q dotnet
                    mkdir dotnet
                    powershell -Command "Invoke-WebRequest -OutFile dotnet-sdk.zip https://download.visualstudio.microsoft.com/download/pr/ce61b908-938b-43ac-8a5d-b6fdf96e66ac/ee308870d3859abdf2a08e44c01e6b2f/dotnet-sdk-8.0.301-win-x64.zip"
                    powershell -Command "Expand-Archive -Path dotnet-sdk.zip -DestinationPath dotnet"
                    del dotnet-sdk.zip
                '''
            }
        }
        stage('Checkout') {
            steps {
                checkout scm
            }
        }
        stage('Restore') {
            steps {
                bat '.\\dotnet\\dotnet.exe restore CalculatorApp\\CalculatorApp.csproj'
                bat '.\\dotnet\\dotnet.exe restore CalculatorTests\\CalculatorTests.csproj'
            }
        }
        stage('Build') {
            steps {
                bat '.\\dotnet\\dotnet.exe build CalculatorApp\\CalculatorApp.csproj --configuration Release'
            }
        }
        stage('Test') {
            steps {
                bat '.\\dotnet\\dotnet.exe test CalculatorTests\\CalculatorTests.csproj'
            }
        }
    }
    post {
        always {
            junit allowEmptyResults: true, testResults: '**/TestResults/*.xml'
        }
        success {
            echo "Build and tests succeeded!"
        }
        failure {
            echo "Build or tests failed."
        }
    }
}
