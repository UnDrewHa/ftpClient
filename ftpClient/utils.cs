using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace ftpClient {
    public sealed class StringUtils {
        public static string ExtractFileFromPath(string fileName, string pathSeparator) {
            int pos = fileName.LastIndexOf(pathSeparator);
            return fileName.Substring(pos + 1);
        }

        public static string ExtractFolderFromPath(string fileName, string pathSeparator, bool includeSeparatorAtEnd) {
            int pos = fileName.LastIndexOf(pathSeparator);
            return fileName.Substring(0, (includeSeparatorAtEnd ? pos + 1 : pos));
        }
    }
}