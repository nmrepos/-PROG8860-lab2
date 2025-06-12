pipeline {
    agent any
    environment {
        DOTNET_ROOT = "${env.WORKSPACE}/dotnet"
        PATH = "${env.WORKSPACE}/dotnet:${env.WORKSPACE}/dotnet/tools:${env.PATH}"
    }
    stages {
        stage('Install .NET SDK') {
            steps {
                sh '''
                    rm -rf dotnet
                    mkdir dotnet
                    cd dotnet
                    wget https://download.visualstudio.microsoft.com/download/pr/ce61b908-938b-43ac-8a5d-b6fdf96e66ac/ee308870d3859abdf2a08e44c01e6b2f/dotnet-sdk-8.0.301-linux-x64.tar.gz -O dotnet-sdk.tar.gz
                    tar -zxf dotnet-sdk.tar.gz
                    rm dotnet-sdk.tar.gz
                    cd ..
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
                sh './dotnet/dotnet restore CalculatorApp/CalculatorApp.csproj'
                sh './dotnet/dotnet restore CalculatorTests/CalculatorTests.csproj'
            }
        }
        stage('Build') {
            steps {
                sh './dotnet/dotnet build CalculatorApp/CalculatorApp.csproj --configuration Release'
            }
        }
        stage('Test') {
            steps {
                sh './dotnet/dotnet test CalculatorTests/CalculatorTests.csproj'
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
