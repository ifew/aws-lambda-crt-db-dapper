# aws-lambda-crt-example

Example C# though Custom Runtime (.Net Core 2.2) working with AWS Lambda Function and MySQL

## This code to show about
- Example custom runtime

## Test and Deploy with AWS CLI

**Deploy**
```
$ cd src/aws-lambda-crt-example
$ dotnet lambda deploy-function {LAMBDA_FUNCTION_NAME} –-function-role {ROLE_NAME}
```

**Try to Run and Get result**
```
$ cd src/aws-lambda-crt-example
$ aws lambda invoke --function-name {LAMBDA_FUNCTION_NAME} output.txt
```