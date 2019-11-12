/*connect led to Pin13 , 
 * open windows form application click button to turn led on and off
 */

int ledPin=13;
void setup() 
{
Serial.begin(9600);
pinMode(ledPin,OUTPUT);
digitalWrite(ledPin,LOW);
}

void loop() 
{
int val=Serial.read()-'0'; 

if(val==1)
{
  Serial.println("Led on");
  digitalWrite(ledPin,HIGH);
}
else if(val==0)
{
Serial.println("Led off");
digitalWrite(ledPin,LOW);
}

Serial.println(val);
Serial.flush(); // clear serial port

}
