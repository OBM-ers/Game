int buttonState;
int lastButtonState = LOW;
unsigned long lastDebounceTime = 0;
unsigned long debounceDelay = 5;
int shortDelayObm = 10;
int longDelayObm = 250;
int delayObm = 250;
int joyStickDelayObm = 10;
//pin variables
int di_AttackButtonPinObm = 9;
int di_JumpButtonPinObm = 8;
int di_MoveRightPinObm = 7;
int di_MoveLeftPinObm = 6;
int di_MoveUpPinObm = 5;

//move buttons
int buttonRightState;
int buttonLeftState;
int buttonUpState;
int buttonDownState;
// action buttons
int buttonAttackState;
int buttonJumpState;

bool allowJumpObm = true;
bool allowAttack = true;
void setup() {
  Serial.begin(115200);

  // startMillis = millis();  //initial start time
  pinMode(di_AttackButtonPinObm, INPUT_PULLUP);
  pinMode(di_JumpButtonPinObm, INPUT_PULLUP);
  pinMode(di_MoveRightPinObm, INPUT_PULLUP);
  pinMode(di_MoveLeftPinObm, INPUT_PULLUP);
  pinMode(di_MoveUpPinObm, INPUT_PULLUP);

}


void loop() {


  //Switch readers
  buttonRightState = digitalRead(di_MoveRightPinObm);
  buttonLeftState = digitalRead(di_MoveLeftPinObm);
  buttonJumpState = digitalRead(di_JumpButtonPinObm);
  buttonAttackState = digitalRead(di_AttackButtonPinObm);
  buttonUpState = digitalRead(di_MoveUpPinObm);
  //Checks if the switch is pressed
  if (buttonRightState == LOW) {
    //Sends a character that unity understands
    Serial.println(1);
    //Waits For the serial data to complete and flushing the transmission buffer
    Serial.flush();
    //Delay to prevent overload on de arduino
    delay(joyStickDelayObm);
  }
  //this proces repeats for all the other switches

  if ( buttonLeftState == LOW) {
    Serial.println(-1);
    Serial.flush();
    delay(joyStickDelayObm);
  }

  
  if ( buttonUpState == LOW) {
    Serial.println(2);
    Serial.flush();
    delay(joyStickDelayObm);
  }


  if ( buttonAttackState == HIGH) {
    Serial.println(6);
    Serial.flush();
    delay(shortDelayObm);
    // delayObm = shortDelayObm;
  }

    if (buttonJumpState == HIGH) {
    Serial.println(5);
    Serial.flush();
    delay(shortDelayObm);
    // delayObm = shortDelayObm;
  }
  if (buttonLeftState == HIGH && buttonRightState == HIGH && buttonJumpState == LOW && buttonAttackState == LOW && buttonUpState == LOW) {
    Serial.println(0);
    Serial.flush();
    delay(shortDelayObm);
  }
}
