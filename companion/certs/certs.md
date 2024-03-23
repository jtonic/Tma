# Certificates

## How to create self-signed certificates

> certs pwd: changeme 


```shell
openssl req -x509 -newkey rsa:4096 -keyout key.pem -out cert.pem -days 730
openssl pkcs12 -export -out certificate.p12 -inkey key.pem -in cert.pem
```

## Display the content of the p12 certificate

```shell
openssl pkcs12 -info -in certificate.p12
```


```shell
curl -k -X POST -d '{"Name":"Tony"}' -H "Content-Type: application/json" https://localhost:5001/greeting
```