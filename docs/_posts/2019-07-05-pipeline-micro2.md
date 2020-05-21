
---
layout: post
author: HectorRPC
---

# Jenkins: Pipeline para micro2

```
pipeline {
    agent {
        label 'windows'
    }
    tools {nodejs "node"}
 
    stages {
        stage('Check nodejs installation') {
            steps {
                bat 'npm config ls'
            }
        }
        stage('Checkout') {
            steps {
                git credentialsId: 'github', url: 'https://github.com/HectorRPC/testing-microservices', branch: 'micro2'
            }
        }
        stage('Install dependencies') {
            steps {
                dir('micro2'){
                    bat "npm install"
                }
            }
        }
        stage('Mocha test') {
            steps {
                dir('micro2'){
                    bat "npm test"
                }
            }
        }
    }
}
```