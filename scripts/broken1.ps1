For($i=1; $i -le 10; $i++){
	where.exe notepad | Out-Default
	Write-Host "$i"
}
