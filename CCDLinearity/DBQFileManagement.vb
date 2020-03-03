'Module for installing the observing list database search file (embedded in the app as querySDBname) also installed as same name.

Imports System.IO
Imports System.Reflection

Module DBQFileManagement

    Public Function DBQInstalled(querySDBname As String) As Boolean
        'Checks to see if search database file is already installed or not
        Dim SDBqueryfilepath = "C:\Users\" + System.Environment.UserName +
            "\Documents\Software Bisque\TheSkyX Professional Edition\Database Queries\" + querySDBname
        Return File.Exists(SDBqueryfilepath)
    End Function

    Public Sub InstallDBQ(querySDBname As String)
        'Installs the dbq file
       
        Dim dstream As Stream
        Dim dassembly As [Assembly]

        Dim SDBqueryfilepath = "C:\Users\" + System.Environment.UserName +
                "\Documents\Software Bisque\TheSkyX Professional Edition\Database Queries\" + querySDBname
        'Collect the file contents to be written
        dassembly = [Assembly].GetExecutingAssembly()
        dstream = dassembly.GetManifestResourceStream("CCDLinearity." + querySDBname)
        Dim dbytes(dstream.Length) As Byte
        Dim dreadout = dstream.Read(dbytes, 0, dstream.Length)
        Dim dbqfile = File.Create(SDBqueryfilepath)
        dbqfile.Close()
        'write to destination file
        My.Computer.FileSystem.WriteAllBytes(SDBqueryfilepath, dbytes, False)
        dstream.Close()

        Return

    End Sub

End Module
