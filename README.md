To create a self-signed certificate using the Command Prompt (`cmd`) or PowerShell, you can use the following steps. Here are two methods: one for each.

### Method 1: Using PowerShell

You can create a self-signed certificate using the `New-SelfSignedCertificate` cmdlet in PowerShell:

```powershell
$cert = New-SelfSignedCertificate -CertStoreLocation Cert:\LocalMachine\My -DnsName "www.yourdomain.com"
```

This command will create a self-signed certificate for the domain `www.yourdomain.com`. You can replace `"www.yourdomain.com"` with your actual domain or a placeholder if you're just testing.

If you want to export the certificate as a `.pfx` file (which can include the private key), you can run:

```powershell
$password = ConvertTo-SecureString -String "YourPassword" -Force -AsPlainText
Export-PfxCertificate -Cert $cert -FilePath "C:\path\to\certificate.pfx" -Password $password
```

Replace `"YourPassword"` with a secure password and `C:\path\to\certificate.pfx` with the desired path and filename.

### Method 2: Using Command Prompt (CMD)

In the Command Prompt, you can use `makecert.exe`, which is part of the Windows SDK, but it’s outdated. Instead, you can use the `certutil` tool:

```cmd
certutil -f -generateSSTFromWU "C:\path\to\your.cer"
```

This command generates a self-signed certificate using the Windows Update trusted root certificate list.

You might need to have administrative privileges to run these commands, especially when accessing or modifying the local machine's certificate store.

### Viewing the Certificate

After generating the certificate, you can view it in the certificate store using the following PowerShell command:

```powershell
Get-ChildItem -Path Cert:\LocalMachine\My
```

This command will list the certificates in the `LocalMachine\My` store.

