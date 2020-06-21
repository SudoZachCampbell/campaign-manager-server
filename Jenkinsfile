pipeline {
  agent any 
  stages {
    stage('Clean') {
      steps {
        sh 'docker container ls'
        sh 'docker image ls'
        sh 'docker ps "ancestor=ddcatalogue"'
        // sh 'docker ps -aqf "ancestor=ddcatalogue" | xargs docker stop | xargs docker rm'
        sh 'docker system prune -f'
        sh 'docker container ls'
        sh 'docker image ls'
      }
    }
    stage('Build') {
      steps {
        sh 'docker build -t ddcatalogue:latest ./DDCatalogue'
        sh 'docker image ls'
      }
    }
    stage('Deploy') {
      steps {

        sh 'docker run -d -p 5001:80 ddcatalogue'
        sh 'docker container ls'
      }
    }
  }
}