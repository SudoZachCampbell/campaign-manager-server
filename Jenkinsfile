pipeline {
  agent any 
  stages {
    stage('Build') {
      steps {
        sh 'docker build ./DDCatalogue'
      }
    }
    stage('Deploy') {
      steps {
        sh 'docker container ls'
        sh 'docker run -p 5001:80 ddcatalogue'
      }
    }
  }
}