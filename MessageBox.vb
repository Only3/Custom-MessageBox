
    Class MessageBox
        Inherits Form

        Private Msg As String
        WithEvents Btn As New Button With {.Text = "OK", .Location = New Point(Width - 100, 80)}

        Sub New()
            Size = New Size(300, 150)
            MinimizeBox = False : MaximizeBox = False
            FormBorderStyle = FormBorderStyle.FixedDialog
            StartPosition = FormStartPosition.CenterParent
            AddHandler Btn.Click, Sub() DialogResult = DialogResult.OK
            Controls.Add(Btn)
        End Sub

        Public Overloads Shared Function Show(Title As String, Message As String)
            Return New MessageBox() With {.Text = Title, .Msg = Message}.ShowDialog()
        End Function

        Protected Overrides Sub onPaint(e As PaintEventArgs)
            e.Graphics.FillRectangle(Brushes.White, New Rectangle(0, 0, ClientRectangle.Width, 70))
            e.Graphics.DrawIcon(SystemIcons.Information, 10, 15)
            e.Graphics.DrawString(Msg, New Font("Segoe UI", 12), Brushes.Blue, New Rectangle(50, 0, Width - 20, 70),
                                  New StringFormat With {.LineAlignment = StringAlignment.Center})
            MyBase.OnPaint(e)
        End Sub
    End Class
