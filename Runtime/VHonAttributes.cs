using System;
using UnityEngine;

/*
[Line]
[ReadOnly]
[Block("")]
*/

public class LineAttribute : PropertyAttribute { }
public class ReadOnlyAttribute : PropertyAttribute { }

[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
public class BlockAttribute : PropertyAttribute
{
    public string title;
    public BlockAttribute(string _title) => title = _title;
}