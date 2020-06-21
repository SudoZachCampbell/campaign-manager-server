pipeline {
  agent {
    dockerfile {
      filename 'Dockerfile'
      dir 'DDCatalogue'
    }

  }
  stages {
    stage('Run') {
      steps {
        sh 'docker run -p 5001:80 ddcatalogue'
      }
    }
  }
}