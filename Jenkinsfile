pipeline {
  agent any 
  stages {
    stage('Clean') {
      steps {
        sh 'docker container ls -a'
        sh 'docker image ls -a'
        sh 'docker ps -aqf "ancestor=ddcatalogue" | xargs docker stop'
        sh 'docker system prune -fa'
        sh 'docker container ls -a'
        sh 'docker image ls -a'
      }
    }
    stage('Build') {
      steps {
        sh 'docker build -t ddcatalogue:latest ./DDCatalogue'
        sh 'docker image ls -a'
      }
    }
    stage('Deploy') {
      steps {

        sh 'docker run -d -p 5001:80 ddcatalogue'
        sh 'docker container ls -a'
      }
    }
  }
}