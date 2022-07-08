Public Class KeuanganAdmin

    Sub tampildata()
        Call sambung()
        DA = New MySql.Data.MySqlClient.MySqlDataAdapter("select*from record_pembayaran", con)
        DS = New DataSet
        DS.Clear()
        DA.Fill(DS, "record_pembayaran")
        DataGridView1.DataSource = (DS.Tables("record_pembayaran"))
    End Sub

    Private Sub KeuanganAdmin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        sambung()
        tampildata()
    End Sub

    Private Sub input_keuangan_Click(sender As Object, e As EventArgs) Handles input_keuangan.Click
        CMD = New MySql.Data.MySqlClient.MySqlCommand(STR, con)
        CMD.Connection = con

        STR = " insert into record_pembayaran(npm, Nama, Jenis_Pembayaran, Tgl_Pembayaran, Nominal) " &
                "values ('" & npm_txt.Text & " ',' " & nama_txt.Text & " ',' " & jenis_txt.Text & " ',' " & tgl_txt.Text & " ',' " & nominal_txt.Text & "')"
        If npm_txt.Text = "" Or npm_txt.Text = "" Or npm_txt.Text = "" Then
            Exit Sub
        End If
        CMD = New MySql.Data.MySqlClient.MySqlCommand(STR, con)
        CMD.ExecuteNonQuery()
        MessageBox.Show("Data Berhasil Ditambahkan", "Notice")
        tampildata()

    End Sub

    Private Sub tgl_txt_ValueChanged(sender As Object, e As EventArgs) Handles tgl_txt.ValueChanged
        tgl_txt.CustomFormat = "dd/MM/yyyy"
    End Sub
End Class