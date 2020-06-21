pipeline {
  agent {
    dockerfile {
      filename 'Dockerfile'
      dir 'DDCatalogue'
    }

  }
  stages {
    stage('Test') {
      steps {
        sh 'dotnet --version'
      }
    }

  }
}