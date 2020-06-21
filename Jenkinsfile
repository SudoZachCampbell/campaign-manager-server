pipeline {
  agent any 
  stages {
    stage('Build') {
      steps {
        sh 'docker build ./DDCatalogue'
        sh 'echo docker image ls'
      }
    }
    stage('Deploy') {
      steps {
        sh 'echo docker container ls'
        sh 'docker run -p 5001:80 ddcatalogue'
      }
    }
  }
}