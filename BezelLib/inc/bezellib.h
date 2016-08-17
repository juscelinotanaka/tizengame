#ifndef _BEZELLIB_H_
#define _BEZELLIB_H_

/**
 * This header file is included to define _EXPORT_.
 */
#include <stdbool.h>
#include <tizen.h>
#include <efl_extension.h>
#include <dlog.h>

#ifdef __cplusplus
extern "C" {
#endif

// This method is exported from bezellib.so
EXPORT_API bool tizenbezellib(void);
EXPORT_API bool logMessage (char *gameObject, char *methodname, char *messageToSend);
EXPORT_API bool registerBezelListener (char *gameObject, char *methodName);

// this signature should be declared to allow sending message back to Unity.
void UnitySendMessage(char *gameObject, char *methodname, char *messageToSend);

#ifdef __cplusplus
}
#endif
#endif // _BEZELLIB_H_

