/**
 * This file contains the exported symbol.
 */
#include "bezellib.h"

char bezelObject[30];
char bezelMethodName[30];

// This is an example of an exported method.
bool tizenbezellib(void) {
	return true;
}

Eina_Bool _rotary_handler_cb(void *data, Eext_Rotary_Event_Info *ev) {
   if (ev->direction == EEXT_ROTARY_DIRECTION_CLOCKWISE)
   {
	   dlog_print(DLOG_INFO, LOG_TAG, "ROTARY HANDLER: Rotary device rotated in clockwise direction");
	   UnitySendMessage(bezelObject, bezelMethodName, "CW");
   }
   else
   {
	   dlog_print(DLOG_INFO, LOG_TAG, "HANDLER: Rotary device rotated in counter clockwise direction");
	   UnitySendMessage(bezelObject, bezelMethodName, "CCW");
   }

   return EINA_FALSE;
}

bool logMessage (char *gameObject, char *methodname, char *messageToSend) {
	dlog_print(DLOG_INFO, "MyTag", "Log Message");
	UnitySendMessage(gameObject, methodname, messageToSend);

	return true;
}

bool registerBezelListener (char *gameObject, char *methodName) {
	eext_rotary_event_handler_add(_rotary_handler_cb, NULL);
	strcpy(bezelObject, gameObject);
	strcpy(bezelMethodName, methodName);
	dlog_print(DLOG_INFO, "MyTag", "Bezel Registered");

	return true;
}
