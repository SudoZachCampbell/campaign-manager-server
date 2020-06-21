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
        sh 'docker run -d -p 5001:80 ddcatalogue'
      }
    }
  }
}