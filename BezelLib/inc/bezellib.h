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

#ifdef  LOG_TAG
#undef  LOG_TAG
#endif
#define LOG_TAG "testapp"

// This method is exported from bezellib.so
EXPORT_API bool tizenbezellib(void);
EXPORT_API bool logMessage (void);

#ifdef __cplusplus
}
#endif
#endif // _BEZELLIB_H_

