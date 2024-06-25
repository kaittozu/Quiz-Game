Public Class QuizPengetahuan

    ' array of questions
    Dim questions() As String = {"Presiden pertama indonesia adalah ..", "100 + 1000 = ?", "5000 + 10.000 = ?", "Langit berwana ..", "100 - 100 = ?"}
    ' array of options
    Dim options(,) As String = {{"Jokowi", "Prabowo", "Soekarno", "Megawati", "Soekarno"},
                                               {"1100", "500", "900", "2000", "1100"},
                                                {"1700", "15000", "20000", "30000", "15000"},
                                                 {"Biru", "Merah", "Putih", "Hitam", "Biru"},
                                                  {"0", "1", "90", "100", "0"}}

    Dim index As Integer = 0
    Dim correct As Integer = 0

    ' create a sub to check the iption selected bu the user
    ' if it's correct or not
    Sub checkAnswer(rbt As RadioButton)

        If rbt.Text.Equals(options(index, 4)) Then
            correct += 1
            rbt.BackColor = Color.Green

        Else
            rbt.BackColor = Color.Red
        End If

        index += 1
        setEnable(False)

    End Sub

    ' uncheck the radiobuttons
    Sub uncheck()

        RadioButton1.Checked = False
        RadioButton2.Checked = False
        RadioButton3.Checked = False
        RadioButton4.Checked = False

    End Sub

    ' reset radiobuttons color
    Sub resetRadio()

        For Each c As Control In Me.Controls

            If TypeOf c Is RadioButton Then

                Dim rdb As RadioButton = c
                rdb.BackColor = Color.White

            End If

        Next

    End Sub

    ' enable or disable radiobuttons
    Sub setEnable(yes_or_no As Boolean)

        RadioButton1.Enabled = yes_or_no
        RadioButton2.Enabled = yes_or_no
        RadioButton3.Enabled = yes_or_no
        RadioButton4.Enabled = yes_or_no

    End Sub

    Private Sub Quiz_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ButtonNext.PerformClick()

    End Sub

    Private Sub ButtonNext_Click(sender As Object, e As EventArgs) Handles ButtonNext.Click



        resetRadio()

        ' restart the quiz
        If ButtonNext.Text.Equals("Mulai ulang Quiz") Then
            index = 0
            correct = 0
            richTextBox_Question.BackColor = Color.White
            richTextBox_Question.ForeColor = Color.Black
            ButtonNext.Text = "Selanjutnya"
        End If

        ' display the score
        If index = questions.Length Then
            richTextBox_Question.Text = "Skormu adalah: " & correct & " / " & questions.Length

            If correct >= CSng(questions.Length) / 2 Then
                richTextBox_Question.BackColor = Color.Green
                richTextBox_Question.ForeColor = Color.White
            Else
                richTextBox_Question.BackColor = Color.Red
                richTextBox_Question.ForeColor = Color.White
            End If

            ButtonNext.Text = "Mulai ulang Quiz"
        Else
            setEnable(True)
            uncheck()
            richTextBox_Question.Text = questions(index)
            RadioButton1.Text = options(index, 0)
            RadioButton2.Text = options(index, 1)
            RadioButton3.Text = options(index, 2)
            RadioButton4.Text = options(index, 3)

            ' if it's the last question
            If index = questions.Length - 1 Then
                ButtonNext.Text = "Selesai dan Lihat Skormu"
            End If
        End If

    End Sub

    Private Sub RadioButton1_Click(sender As Object, e As EventArgs) Handles RadioButton1.Click

        checkAnswer(RadioButton1)

    End Sub

    Private Sub RadioButton2_Click(sender As Object, e As EventArgs) Handles RadioButton2.Click

        checkAnswer(RadioButton2)

    End Sub

    Private Sub RadioButton3_Click(sender As Object, e As EventArgs) Handles RadioButton3.Click

        checkAnswer(RadioButton3)

    End Sub

    Private Sub RadioButton4_Click(sender As Object, e As EventArgs) Handles RadioButton4.Click

        checkAnswer(RadioButton4)

    End Sub


    Private Sub soal_Click(sender As Object, e As EventArgs)



    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged

    End Sub
End Class