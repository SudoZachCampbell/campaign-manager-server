pipeline {
  agent any 
  stages {
    stage('Clean') {
      steps {
        sh 'docker container ls -a'
        // sh 'docker ps -aqf "ancestor=ddcatalogue" | xargs docker stop | xargs docker rm'
        sh 'docker container rename ddcatalogue ddcatalogue_old || true'
        sh 'docker container stop ddcatalogue_old'
        sh 'docker container ls -a'
      }
      post {
        failure {
            echo 'This build has failed. See logs for details.'
            sh 'docker container rename ddcatalogue_old ddcatalogue || true'
        }
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
        sh 'docker run -d -p 5000:80 --name ddcatalogue ddcatalogue'
        sh 'docker container ls -a'
        sh 'docker container rm ddcatalogue_old'
      }
      post {
        failure {
            echo 'This build has failed. See logs for details.'
            sh 'docker container rename ddcatalogue_old ddcatalogue'
        }
      }   
    }
  }
}