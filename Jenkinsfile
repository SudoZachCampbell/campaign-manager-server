pipeline {
  agent any 
  stages {
    stage('Clean') {
      steps {
        sh 'docker container ls -a'
        sh 'docker container rename ddcatalogueapi ddcatalogueapi_old || true'
        sh 'docker container stop ddcatalogueapi_old || true'
        sh 'docker container ls -a'
      }
      post {
        failure {
            echo 'This build has failed. See logs for details.'
            sh 'docker container rename ddcatalogueapi_old ddcatalogueapi || true'
        }
      }   
    }
    stage('Build') {
      steps {
        sh 'docker build -t ddcatalogueapi:latest ./DDCatalogue'
        sh 'docker image ls -a'
      }
    }
    stage('Deploy') {
      steps {
        sh 'docker ps -aqf "ancestor=ddcatalogueapi" | xargs docker stop | xargs docker rm || true'
        sh 'docker run -d -p 5000:80 --name ddcatalogueapi ddcatalogueapi'
        sh 'docker container ls -a'
        sh 'docker container rm ddcatalogueapi_old || true'
      }
      post {
        failure {
            echo 'This build has failed. See logs for details.'
            sh 'docker container rename ddcatalogueapi_old ddcatalogueapi || true'
        }
      }   
    }
  }
}