pipeline {
  agent any 
  stages {
    stage('Build') {
      steps {
        sh 'docker build -t ddcatalogue:latest ./DDCatalogue'
        sh 'docker image ls'
      }
    }
    stage('Deploy') {
      steps {
        sh 'docker run -p 5001:80 ddcatalogue'
        sh 'docker container ls'
      }
    }
  }
}