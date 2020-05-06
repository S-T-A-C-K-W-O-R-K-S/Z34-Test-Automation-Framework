# serves the target application at http://localhost:555/
# requires the target application to be unzipped

$PATH = Read-Host -Prompt "Enter Target Application Path"
http-server $PATH --port 555 --cors
