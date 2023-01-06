import requests as req

r = req.get('https://github.com/lucas-watkins/gazette-notifications-winforms/raw/main/binarys/setup-gzn-winforms-1.0.exe', allow_redirects= True)

open('setup-gzn-winforms-1.0.exe', 'wb').write(r.content)