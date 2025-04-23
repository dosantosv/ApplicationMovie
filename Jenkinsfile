pipeline {
  agent any
  stages {
    stage('Build') {
      parallel {
        stage('Build') {
          steps {
            sh 'echo "Instalando dependências..."'
          }
        }

        stage('Test') {
          steps {
            sh 'echo "Executando testes..."'
          }
        }

        stage('Deploy') {
          steps {
            sh 'echo "Realizando deploy..."'
          }
        }

      }
    }

  }
}