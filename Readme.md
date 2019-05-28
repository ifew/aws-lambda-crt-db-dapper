# Example AWS Lambda C# .NET Core 2.2 though Custom Runtime (Amazon.Lambda.RuntimeSupport) with connect MySQL and Dapper

Example for optimize cold start with Amazon.Lambda.RuntimeSupport

## This code to show about
- Example code for using Amazon.Lambda.RuntimeSupport and connect MySQL and Dapper

## Test and Deploy with AWS CLI

**Deploy**
```
$ cd src/aws-lambda-crt-db
$ dotnet lambda deploy-function {LAMBDA_FUNCTION_NAME} –-function-role {ROLE_NAME}
```

**Try to Run and Get result**
```
$ cd src/aws-lambda-crt-db
$ aws lambda invoke --function-name {LAMBDA_FUNCTION_NAME} output.txt
```
