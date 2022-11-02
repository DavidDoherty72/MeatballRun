using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Internal;

namespace Doodah.Utils
{
  public class TimeKeeper
  {
    public static long GetTimestamp()
    {
      return System.DateTime.UtcNow.Ticks / 10000000;
    }

    public static long GetTimestampAsSeconds()
    {
      return GetTimestamp() / 1000;
    }

    public static long TimestampElapsed(long timestampPast, long timestampFuture)
    {
      return timestampFuture - timestampPast;
    }
  }
}
