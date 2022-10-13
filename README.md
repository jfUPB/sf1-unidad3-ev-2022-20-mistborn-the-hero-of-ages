# Protocolos binarios
## Carolina Arboleda y Jerónimo Cano
Utilizando la librería de Adafruit_MPU6050 y por medio de funciones integradas a esta llevamos los valores de la aceleración del acelerómetro al programa. Después, en el loop del programa, el microprocesador copia los bytes de los valores flotantes de cada eje de la aceleración a un mismo arreglo de 12 posiciones (4 bytes por cada float). Este arreglo se está actualizando todo el tiempo.

Por su parte, el programa del pc (Unity) cada 25 milisegundos envía por el puerto serial un commando, "ask\n", y el microprocesador lo recibe y actúa en consecuencia, enviando los últimos valores guardados en el arreglo de la aceleración por ejes. 

Unity, una vez reciba estos bytes, los toma y los convierte de nuevo en floats que guarda en tres variables, qx, qy y qz. Tras esto transforma la rotación del GameObject al que está ligado el script (en este caso el prisma rectangular) generando un cuaternión que se crea con las tres variables y un qw vacío.

Esto último es muy impreciso, haciendo que la rotación sea poco fluida y calibrada de una manera extraña. Podría mejorarse aprovechando la capacidad del MPU de generar un cuaternión, se transmitirían 16 bytes en lugar de 12 y se enviaría directamente este cuaternión para transformar la rotación del GameObject.
