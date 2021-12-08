Imports Capa_Servicio
Public Class Estudiante
    Inherits System.Web.UI.Page

    Dim ws As ServiceReference1.WebService1SoapClient = New ServiceReference1.WebService1SoapClient()
    Dim obj_Estud As Estud = New Estud()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If (ddl_Facultad.Items.Count = 0) Then
            ddl_Facultad.DataSource = ws.Buscar_Facultad()
            ddl_Facultad.DataTextField = "facultad"
            ddl_Facultad.DataValueField = "codigo"
            ddl_Facultad.DataBind()
        End If

        If (ddl_Carrera.Items.Count = 0) Then
            ddl_Carrera.DataSource = ws.Buscar_Carrera()
            ddl_Carrera.DataTextField = "carrera"
            ddl_Carrera.DataValueField = "cod_carrera"
            ddl_Carrera.DataBind()
        End If
    End Sub

    Protected Sub btn_Buscar_Click(sender As Object, e As EventArgs) Handles btn_Buscar.Click
        Dim obj_Estudiante_Reg As ServiceReference1.Estudiante_Reg = New ServiceReference1.Estudiante_Reg()


        If obj_Estud.buscar(txt_Cedula.Text) Then
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
            ddl_Carrera.DataSource = ws.Buscar_Carrera()
            ddl_Carrera.DataTextField = "carrera"
            ddl_Carrera.DataValueField = "cod_carrera"
            ddl_Carrera.DataBind()
            ddl_Carrera.Focus()
            ddl_Carrera.SelectedValue = obj_Estudiante_Reg.carrera
            txt_Indice.Text = obj_Estudiante_Reg.indice
            txt_Sexo.Text = obj_Estudiante_Reg.sexo
            txt_Estatus.Text = obj_Estudiante_Reg.status
            btn_Modificar.Enabled = True
            btn_Eliminar.Enabled = True
            btn_Agregar.Enabled = False
            txt_Cedula.Enabled = False
            txt_Nombre.Enabled = True
            txt_Apellido.Enabled = True
            txt_Direccion.Enabled = True
            txt_Celular.Enabled = True
            txt_Correo.Enabled = True
            ddl_Facultad.Enabled = True
            ddl_Carrera.Enabled = True
            txt_Indice.Enabled = True
            txt_Sexo.Enabled = True
            txt_Estatus.Enabled = True
            btn_Buscar.Enabled = False
        Else
            txt_Nombre.Text = ""
            txt_Apellido.Text = ""
            txt_Direccion.Text = ""
            txt_Celular.Text = ""
            txt_Correo.Text = ""
            ddl_Facultad.SelectedValue = "00"
            ddl_Carrera.SelectedValue = "00"
            txt_Indice.Text = ""
            txt_Sexo.Text = ""
            txt_Estatus.Text = ""
            txt_Cedula.Enabled = False
            txt_Nombre.Enabled = True
            txt_Apellido.Enabled = True
            txt_Direccion.Enabled = True
            txt_Celular.Enabled = True
            txt_Correo.Enabled = True
            ddl_Facultad.Enabled = True
            ddl_Carrera.Enabled = True
            txt_Indice.Enabled = True
            txt_Sexo.Enabled = True
            txt_Estatus.Enabled = True
            btn_Agregar.Enabled = True
            btn_Buscar.Enabled = False
            btn_Modificar.Enabled = False
            btn_Eliminar.Enabled = False
        End If
    End Sub

    Protected Sub btn_Limpiar_Click(sender As Object, e As EventArgs) Handles btn_Limpiar.Click
        txt_Cedula.Text = ""
        txt_Nombre.Text = ""
        txt_Apellido.Text = ""
        txt_Direccion.Text = ""
        txt_Celular.Text = ""
        txt_Correo.Text = ""
        ddl_Facultad.SelectedValue = "00"
        ddl_Carrera.SelectedValue = "00"
        txt_Indice.Text = ""
        txt_Sexo.Text = ""
        txt_Estatus.Text = ""
        btn_Buscar.Enabled = True
        btn_Agregar.Enabled = False
        btn_Modificar.Enabled = False
        btn_Eliminar.Enabled = False
        txt_Cedula.Enabled = True
        txt_Nombre.Enabled = False
        txt_Apellido.Enabled = False
        txt_Direccion.Enabled = False
        txt_Celular.Enabled = False
        txt_Correo.Enabled = False
        ddl_Facultad.Enabled = False
        ddl_Carrera.Enabled = False
        txt_Indice.Enabled = False
        txt_Sexo.Enabled = False
        txt_Estatus.Enabled = False
    End Sub

    Protected Sub btn_Listar_Click(sender As Object, e As EventArgs) Handles btn_Listar.Click
        gv_Listar.DataSource = ws.Listar_Estudiante()
        gv_Listar.DataBind()
    End Sub

    Protected Sub btn_Agregar_Click(sender As Object, e As EventArgs) Handles btn_Agregar.Click

        If ws.Agregar_Estudiante(txt_Cedula.Text, txt_Nombre.Text, txt_Apellido.Text,
                               txt_Direccion.Text, txt_Celular.Text, txt_Correo.Text, ddl_Facultad.SelectedValue,
                               ddl_Carrera.SelectedValue, txt_Indice.Text, txt_Sexo.Text, txt_Estatus.Text) Then
            Response.Write("<script>alert('Estudiante Agregado');</script>")
        Else
            Response.Write("<script>alert('No se ha agregado correctamente. Contacte con el administrador!');</script>")
        End If
    End Sub

    Protected Sub btn_Modificar_Click(sender As Object, e As EventArgs) Handles btn_Modificar.Click
        If txt_Estatus.Text = "A" Then

            If ws.Actualizar_Estudiante(txt_Cedula.Text, txt_Nombre.Text, txt_Apellido.Text,
                               txt_Direccion.Text, txt_Celular.Text, txt_Correo.Text, ddl_Facultad.SelectedValue,
                               ddl_Carrera.SelectedValue, txt_Indice.Text, txt_Sexo.Text,
                               txt_Estatus.Text) Then
                Response.Write("<script>alert('Estudiante modificado. Estatus Activo');</script>")
            Else
                Response.Write("<script>alert('Error al modificar estudiante');</script>")
            End If
        ElseIf txt_Estatus.Text = "I" Then

            If ws.Actualizar_Estudiante(txt_Cedula.Text, txt_Nombre.Text, txt_Apellido.Text,
                               txt_Direccion.Text, txt_Celular.Text, txt_Correo.Text, ddl_Facultad.SelectedValue,
                               ddl_Carrera.SelectedValue, txt_Indice.Text, txt_Sexo.Text,
                               txt_Estatus.Text) Then
                Response.Write("<script>alert('Estudiante modificado. Está inactivo.');</script>")
                txt_Cedula.Enabled = False
                txt_Nombre.Enabled = False
                txt_Apellido.Enabled = False
                txt_Direccion.Enabled = False
                txt_Correo.Enabled = False
                txt_Celular.Enabled = False
                ddl_Facultad.Enabled = False
                ddl_Carrera.Enabled = False
                txt_Indice.Enabled = False
                txt_Sexo.Enabled = False
            Else
                Response.Write("<script>alert('Error al modificar estudiante');</script>")
            End If
        Else
            Response.Write("<script>alert('Solo se permiten las letras A (usuario activo), I (usuario inactivo)');</script>")
        End If
    End Sub

    Protected Sub btn_Eliminar_Click(sender As Object, e As EventArgs) Handles btn_Eliminar.Click
        If ws.Eliminar_Estudiante(txt_Cedula.Text) Then
            Response.Write("<script>alert('Estudiante eliminado');</script>")
            txt_Cedula.Text = ""
            txt_Nombre.Text = ""
            txt_Apellido.Text = ""
            txt_Direccion.Text = ""
            txt_Celular.Text = ""
            txt_Correo.Text = ""
            ddl_Facultad.SelectedValue = "00"
            ddl_Carrera.SelectedValue = "00"
            txt_Indice.Text = ""
            txt_Sexo.Text = ""
            txt_Estatus.Text = ""
            btn_Buscar.Enabled = True
            btn_Agregar.Enabled = False
            btn_Modificar.Enabled = False
            btn_Eliminar.Enabled = False
            txt_Cedula.Enabled = True
            txt_Nombre.Enabled = False
            txt_Apellido.Enabled = False
            txt_Direccion.Enabled = False
            txt_Celular.Enabled = False
            txt_Correo.Enabled = False
            ddl_Facultad.Enabled = False
            ddl_Carrera.Enabled = False
            txt_Indice.Enabled = False
            txt_Sexo.Enabled = False
            txt_Estatus.Enabled = False
        Else
            Response.Write("<script>alert('Error al eliminar al profesor');</script>")
        End If
    End Sub
End Class