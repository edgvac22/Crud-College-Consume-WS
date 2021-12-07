Imports capa_servicio
Public Class Profesor
    Inherits System.Web.UI.Page
    Dim ws As ServiceReference1.WebService1SoapClient = New ServiceReference1.WebService1SoapClient()
    Dim obj_Profe As Profe = New Profe()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If (ddl_Facultad.Items.Count = 0) Then
            ddl_Facultad.DataSource = ws.Buscar_Facultad()
            ddl_Facultad.DataTextField = "facultad"
            ddl_Facultad.DataValueField = "codigo"
            ddl_Facultad.DataBind()
        End If

        If (ddl_Categoria.Items.Count = 0) Then
            ddl_Categoria.DataSource = ws.Buscar_Categoria()
            ddl_Categoria.DataTextField = "categoria"
            ddl_Categoria.DataValueField = "codigo"
            ddl_Categoria.DataBind()
        End If
    End Sub

    Protected Sub btn_Buscar_Click(sender As Object, e As EventArgs) Handles btn_Buscar.Click
        Dim obj_Profesor_Reg As ServiceReference1.Profesor_Reg = New ServiceReference1.Profesor_Reg()


        If obj_Profe.buscar(txt_Codigo.Text) Then
            obj_Profesor_Reg = ws.Buscar_Profesor_Reg(txt_Codigo.Text)
            txt_Codigo.Text = obj_Profesor_Reg.codigo
            txt_Cedula.Text = obj_Profesor_Reg.cedula
            txt_Nombre.Text = obj_Profesor_Reg.nombre
            txt_Apellido.Text = obj_Profesor_Reg.apellido
            txt_Direccion.Text = obj_Profesor_Reg.direccion
            txt_Celular.Text = obj_Profesor_Reg.celular
            txt_Correo.Text = obj_Profesor_Reg.correo
            ddl_Facultad.DataSource = ws.Buscar_Facultad()
            ddl_Facultad.DataTextField = "facultad"
            ddl_Facultad.DataValueField = "codigo"
            ddl_Facultad.DataBind()
            ddl_Facultad.Focus()
            ddl_Facultad.SelectedValue = obj_Profesor_Reg.facultad
            ddl_Categoria.DataSource = ws.Buscar_Categoria()
            ddl_Categoria.DataTextField = "categoria"
            ddl_Categoria.DataValueField = "codigo"
            ddl_Categoria.DataBind()
            ddl_Categoria.Focus()
            ddl_Categoria.SelectedValue = obj_Profesor_Reg.categoria
            txt_Salario.Text = obj_Profesor_Reg.salario
            txt_Estatus.Text = obj_Profesor_Reg.status
            btn_Modificar.Enabled = True
            btn_Eliminar.Enabled = True
            btn_Agregar.Enabled = False
            txt_Codigo.Enabled = False
            txt_Cedula.Enabled = False
            txt_Nombre.Enabled = True
            txt_Apellido.Enabled = True
            txt_Direccion.Enabled = True
            txt_Celular.Enabled = True
            txt_Correo.Enabled = True
            ddl_Facultad.Enabled = True
            ddl_Categoria.Enabled = True
            txt_Salario.Enabled = True
            txt_Estatus.Enabled = True
            btn_Buscar.Enabled = False
        Else
            txt_Cedula.Text = ""
            txt_Nombre.Text = ""
            txt_Apellido.Text = ""
            txt_Direccion.Text = ""
            txt_Celular.Text = ""
            txt_Correo.Text = ""
            ddl_Facultad.SelectedValue = "00"
            ddl_Categoria.SelectedValue = "00"
            txt_Salario.Text = ""
            txt_Estatus.Text = ""
            txt_Codigo.Enabled = False
            txt_Cedula.Enabled = True
            txt_Nombre.Enabled = True
            txt_Apellido.Enabled = True
            txt_Direccion.Enabled = True
            txt_Celular.Enabled = True
            txt_Correo.Enabled = True
            ddl_Facultad.Enabled = True
            ddl_Categoria.Enabled = True
            txt_Salario.Enabled = True
            txt_Estatus.Enabled = True
            btn_Agregar.Enabled = True
            btn_Buscar.Enabled = False
            btn_Modificar.Enabled = False
            btn_Eliminar.Enabled = False
        End If

    End Sub

    Protected Sub btn_Limpiar_Click(sender As Object, e As EventArgs) Handles btn_Limpiar.Click
        txt_Codigo.Text = ""
        txt_Cedula.Text = ""
        txt_Nombre.Text = ""
        txt_Apellido.Text = ""
        txt_Direccion.Text = ""
        txt_Celular.Text = ""
        txt_Correo.Text = ""
        ddl_Facultad.SelectedValue = "00"
        ddl_Categoria.SelectedValue = "00"
        txt_Salario.Text = ""
        txt_Estatus.Text = ""
        btn_Buscar.Enabled = True
        btn_Agregar.Enabled = False
        btn_Modificar.Enabled = False
        btn_Eliminar.Enabled = False
        txt_Codigo.Enabled = True
        txt_Cedula.Enabled = False
        txt_Nombre.Enabled = False
        txt_Apellido.Enabled = False
        txt_Direccion.Enabled = False
        txt_Celular.Enabled = False
        txt_Correo.Enabled = False
        ddl_Facultad.Enabled = False
        ddl_Categoria.Enabled = False
        txt_Salario.Enabled = False
        txt_Estatus.Enabled = False
    End Sub

    Protected Sub btn_Listar_Click(sender As Object, e As EventArgs) Handles btn_Listar.Click
        gv_Listar.DataSource = ws.Listar_Profesor()
        gv_Listar.DataBind()
    End Sub

    Protected Sub btn_Agregar_Click(sender As Object, e As EventArgs) Handles btn_Agregar.Click

        If ws.Agregar_Profesor(txt_Codigo.Text, txt_Cedula.Text, txt_Nombre.Text, txt_Apellido.Text,
                               txt_Direccion.Text, txt_Celular.Text, txt_Correo.Text, ddl_Facultad.SelectedValue,
                               ddl_Categoria.SelectedValue, txt_Salario.Text, txt_Estatus.Text) Then
            Response.Write("<script>alert('Profesor Agregado');</script>")
        Else
            Response.Write("<script>alert('No se ha agregado correctamente. Contacte con el administrador!');</script>")
        End If
    End Sub

    Protected Sub btn_Modificar_Click(sender As Object, e As EventArgs) Handles btn_Modificar.Click
        If txt_Estatus.Text = "A" Then

            If ws.Actualizar_Profesor(txt_Nombre.Text, txt_Apellido.Text,
                               txt_Direccion.Text, txt_Celular.Text, txt_Correo.Text, ddl_Facultad.SelectedValue,
                               ddl_Categoria.SelectedValue, txt_Salario.Text, txt_Estatus.Text) Then
                MsgBox("Estudiante modificado. Estatus Activo")
            Else
                MsgBox("Error al modificar estudiante")
            End If
        ElseIf txt_Estatus.Text = "I" Then

            If ws.Actualizar_Profesor(txt_Nombre.Text, txt_Apellido.Text,
                               txt_Direccion.Text, txt_Celular.Text, txt_Correo.Text, ddl_Facultad.SelectedValue,
                               ddl_Categoria.SelectedValue, txt_Salario.Text, txt_Estatus.Text) Then
                MsgBox("Estudiante modificado. Está inactivo.")
                txt_Cedula.Enabled = False
                txt_Nombre.Enabled = False
                txt_Apellido.Enabled = False
                txt_Direccion.Enabled = False
                txt_Correo.Enabled = False
                txt_Celular.Enabled = False
                ddl_Facultad.Enabled = False
                ddl_Categoria.Enabled = False
                txt_Salario.Enabled = False
            Else
                MsgBox("Error al modificar estudiante")
            End If
        Else
            MsgBox("Solo se permiten las letras A (usuario activo), I (usuario inactivo)")
        End If
    End Sub
End Class