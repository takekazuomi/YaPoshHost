For($i=1; $i -le 10; $i++){
  $Host.UI.RawUI.WindowTitle
  where.exe notepad  | Out-Default
}
