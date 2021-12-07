Public Class Estudiante
    Inherits System.Web.UI.Page

    Dim ws As ServiceReference1.WebService1SoapClient = New ServiceReference1.WebService1SoapClient()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ddl_Facultad.SelectedValue = "00"
        ddl_Facultad.DataSource = ws.Buscar_Facultad()
        ddl_Facultad.DataTextField = "facultad"
        ddl_Facultad.DataValueField = "codigo"
        ddl_Facultad.DataBind()
        ddl_Facultad.Focus()
        'ddl_Carrera.SelectedValue = "00"
        'ddl_Carrera.DataSource = ws.Buscar_Carrera()
        'ddl_Carrera.DataTextField = "carrera"
        'ddl_Carrera.DataValueField = "cod_carrera"
        'ddl_Carrera.DataBind()
        'ddl_Carrera.Focus()
    End Sub

    Protected Sub btn_Buscar_Click(sender As Object, e As EventArgs) Handles btn_Buscar.Click
        Dim obj_Estudiante_Reg As ServiceReference1.Estudiante_Reg = New ServiceReference1.Estudiante_Reg()
        obj_Estudiante_Reg = ws.Buscar_Estudiante_Reg(txt_Cedula.Text)
        txt_Cedula.Text = obj_Estudiante_Reg.cedula
        txt_Nombre.Text = obj_Estudiante_Reg.nombre
        txt_Apellido.Text = obj_Estudiante_Reg.apellido
        txt_Direccion.Text = obj_Estudiante_Reg.direccion
        txt_Celular.Text = obj_Estudiante_Reg.celular
        txt_Correo.Text = obj_Estudiante_Reg.correo
        ddl_Facultad.DataSource = ws.Buscar_Facultad()
        ddl_Facultad.DataTextField = "facultad"
        ddl_Facultad.DataValueField = "codigo"
        ddl_Facultad.DataBind()
        ddl_Facultad.Focus()
        ddl_Facultad.SelectedValue = obj_Estudiante_Reg.facultad
        'ddl_Carrera.DataSource = ws.Buscar_Carrera()
        'ddl_Carrera.DataTextField = "carrera"
        'ddl_Carrera.DataValueField = "cod_carrera"
        'ddl_Carrera.DataBind()
        'ddl_Carrera.Focus()
        'ddl_Carrera.SelectedValue = obj_Estudiante_Reg.carrera
        txt_Indice.Text = obj_Estudiante_Reg.indice
        txt_Sexo.Text = obj_Estudiante_Reg.sexo
        txt_Estatus.Text = obj_Estudiante_Reg.status
    End Sub
End Class