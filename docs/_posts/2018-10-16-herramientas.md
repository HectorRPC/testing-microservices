---
layout: post
author: HectorRPC
---

# Tecnologías de desarrollo y herramientas

En este post indicaré las herramientas y tecnologías que, al inicio del proyecto, he decidido utilizar:
- ### Documentación: 
    Tras investigar un poco, he descubierto [Jekyll](https://jekyllrb.com/), una gema de Ruby que permite generar documentación estática. Encuentro esta herramienta especialmente útil debido a que me permite aunar la documentación y el blog en un mismo sitio. Más concretamente, en el repositorio del proyecto.
- ### Arquitectura de microservicios:
    En resumidas cuentas, la arquitectura de microservicios se basa en separar las distintas funcionalidades de una solución en distintos elementos independientes. Esto permite gran escalabilidad, tolerancia a fallos, etc.
    Para determinar cómo deben relacionarse unos servicios con otros, existe una pieza central. Esta pieza puede ser un servicio al cual se conecte el cliente y este consuma los microservicios, o puede tratarse de un broker de mensajes. Como a nivel profesional ya he trabajado utilizando el primer método, a fin de ampliar mis conocimientos sobre esta arquitectura, he decidido utilizar un broker. Más concretamente, [RabbitMQ](https://www.rabbitmq.com/). Se trata de un broker open source que dispone de despliegue con Docker, una tecnología que estará muy presente en este proyecto.
- ### Lenguaje de desarrollo
    Como lenguaje para el desarrollo de los microservicios he optado, inicialmente, por [ASP.NET Core](https://docs.microsoft.com/es-es/aspnet/core/). Tras debatirme entre esta y NodeJS, las cuales ambas permiten despliegue en Docker, me he decidido por la primera debido a que ya he trabajo con ASP.NET Framework, dándome así ventaja.
- ### IDE
    [Visual Studio Code](https://code.visualstudio.com/) es un IDE muy potente, open source, que dispone de muchas extensiones para CI y CD. Si bien Visual Studio ofrece una versión Community gratuita y aun más potente, resulta más pesado.