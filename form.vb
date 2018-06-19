 Public Function generate_reply(ByVal MainComment() As String)
        Dim reader As StreamReader = My.Computer.FileSystem.OpenTextFileReader(txtsrcfile.Text)
        Dim a As String
        Dim final As String
        Do
            Try
                a = reader.ReadLine.Replace(vbCr, "").Replace(vbLf, "").Replace(vbCrLf, "")
                Dim words() As String = a.Split("|-|")
                Dim srcstring = words(0)
                For i = 0 To MainComment.Count - 1
                    If srcstring.ToLower.Contains(MainComment(i).ToLower) Then
                        Dim replyparts() As String = words(2).Split(",")
                        Dim Generator As System.Random = New System.Random()
                        final = replyparts(Generator.Next(0, replyparts.Count - 1))

                    End If
                Next

            Catch ex As Exception
                Exit Do
            End Try
        Loop Until a Is Nothing
        reader.Close()
        If final = Nothing Then
            final = txtdefaultreply.Text
        End If
        Return final
    End Function
