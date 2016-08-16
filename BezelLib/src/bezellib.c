/**
 * This file contains the exported symbol.
 */
#include "bezellib.h"

// This is an example of an exported method.
bool
tizenbezellib(void)
{
	return true;
}

Eina_Bool _rotary_handler_cb(void *data, Eext_Rotary_Event_Info *ev) {
   if (ev->direction == EEXT_ROTARY_DIRECTION_CLOCKWISE)
   {
      //dlog_print(DLOG_INFO, LOG_TAG, "ROTARY HANDLER: Rotary device rotated in clockwise direction");
   }
   else
   {
      //dlog_print(DLOG_INFO, LOG_TAG, "Rotary device rotated in counter clockwise direction");
   }

   return EINA_FALSE;
}

bool logMessage (void) {
	eext_rotary_event_handler_add(_rotary_handler_cb, NULL);
	dlog_print(DLOG_INFO, LOG_TAG, "Event Registered");

	return true;
}
