using System;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential)]
public struct FileEntry
{
    public int Ofs;
    public int Size;
}