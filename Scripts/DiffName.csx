#!/usr/bin/env dotnet-script

using System;
using System.IO;
using System.Linq;

string dir1 = @"C:/Users/lenovo/Music/VipSongsDownload"; // 替换为第一个目录路径
string dir2 = @"E:/temp"; // 替换为第二个目录路径

try
{
    // 获取两个目录的文件名（不带后缀）并排序
    var files1 = Directory.GetFiles(dir1)
        .Select(f => Path.GetFileNameWithoutExtension(f))
        .OrderBy(n => n, StringComparer.OrdinalIgnoreCase)
        .ToList();

    var files2 = Directory.GetFiles(dir2)
        .Select(f => Path.GetFileNameWithoutExtension(f))
        .OrderBy(n => n, StringComparer.OrdinalIgnoreCase)
        .ToList();

    // 逐个比较文件名
    int maxIndex = Math.Min(files1.Count, files2.Count);
    for (int i = 0; i < maxIndex; i++)
    {
        if (!string.Equals(files1[i], files2[i], StringComparison.OrdinalIgnoreCase))
        {
            Console.WriteLine($"发现差异：'{files1[i]}'（目录1） vs '{files2[i]}'（目录2）");
            return;
        }
    }

    // 处理目录长度不同的情况
    if (files1.Count != files2.Count)
    {
        string diffFile = files1.Count > files2.Count
            ? files1[maxIndex]
            : files2[maxIndex];

        string diffDir = files1.Count > files2.Count ? dir1 : dir2;
        Console.WriteLine($"发现差异：文件 '{diffFile}' 仅存在于目录 {diffDir}");
        return;
    }

    Console.WriteLine("两个目录的文件名完全一致");
}
catch (DirectoryNotFoundException ex)
{
    Console.WriteLine($"目录不存在：{ex.Message}");
}
catch (UnauthorizedAccessException ex)
{
    Console.WriteLine($"访问被拒绝：{ex.Message}");
}
