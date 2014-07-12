Bricelam.Blink1Lib
==================

My version of a .NET API on top of blink1-lib

## Example

Here's how to use it.

```C#
// Connect to the blink(1) mk2
using (var blink1 = new Blink1Mk2())
{
    // Blink white three times
    for (int i = 0; i < 3; i++)
    {
        blink1.SetColor(255, 255, 255);
        Thread.Sleep(500);
        blink1.SetColor(0, 0, 0);
        Thread.Sleep(500);
    }
}
```

See Blink1Sample under the samples directory for more examples.
