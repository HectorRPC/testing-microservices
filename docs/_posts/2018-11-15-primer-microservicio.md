---
layout: post
author: HectorRPC
---

# Publicación de mensajes en RabbitMQ con .NETCore

Ya se encuentra en la rama _micro1_ el nucleo del primer microservicio. Este microservicio permite emitir mensajes en una cola de RabbitMQ. El servicio está montado mediante inyección de dependencias, por lo que para añadir otro broker de mensajes (Kafka, por ejemplo), bastaría con implementar la interfaz correspondiente (IMessageBroker), así como indicar en el fichero _appsettings.json_ el tipo de broker que se utilizará.


## Próximo paso

El próximo paso, lógicamente, es crear un segundo microservicio que consuma los mensajes producidos por el primero. Una vez esté creado, este microservicio deberá responder al mensaje recibido, una vez este haya sido procesado. Esto plantea una decisión acerca de qué arquitectura utilizar en el primer microservicio:
- Por una parte, se puede esperar a recibir una respuesta de manera síncrona.
- Por otra parte, se puede escuchar en una cola las respuestas de manera asíncrona, notificando en tiempo real de los datos recibidos.

La primera opción resulta poco escalable si se quiere procesar el mensaje emitido por el servicio 1 de manera concurrente por varios servicios. De esta manera, me inclino por la segunda opción