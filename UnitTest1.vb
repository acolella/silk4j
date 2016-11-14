Imports System
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports experitestClient

Namespace Experitest

    <TestClass()>
    Public Class Novo_Teste
        Dim host As String = "localhost"
        Dim port As Integer = 8889
        Dim projectBaseDirectory As String = "C:\\Users\\antonio.silva\\workspace\\project3"
        Dim client As Client

        <TestInitialize()>
        Public Sub SetupTest()
            client = New Client(host, port, True)
            client.SetProjectBaseDirectory(projectBaseDirectory)
            client.SetReporter("xml", "reports", "Novo_Teste")
        End Sub

        <TestMethod()>
        Public Sub TestNovo_Teste()
            client.SetDevice("adb:SM-E500M")
            client.SendText("{HOME}")
            client.Click("NATIVE", "xpath=//*[@text='Itaú']", 0, 1)
            client.Click("NATIVE", "xpath=//*[@id='edit_agency_account_agency']", 0, 1)
            client.SendText("{ESC}")
            If client.WaitForElement("NATIVE", "xpath=//*[@text='acessar']", 0, 60000) Then
                'If statement
            End If
            client.Click("NATIVE", "xpath=//*[@text='acessar']", 0, 1)
            client.VerifyElementFound("NATIVE", "xpath=//*[@text='Agência e/ou conta inválida. Por favor, digite novamente.']", 0)
            'client.SendText("{event:Save Event}")
        End Sub

        <TestCleanup()>
        Public Sub TearDown()
            'Generates a report of the test case.
            'For more information - http://supportline.microfocus.com/Documentation/books/ASQ/SilkMobile/90/help/Report_Of_Executed_Script.htm:
            client.GenerateReport(False)
            'Releases the client so that other clients can approach the agent in the near future. 
            client.ReleaseClient()
        End Sub
    End Class
End Namespace