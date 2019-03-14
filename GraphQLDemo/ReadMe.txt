
Use Postman to send a POST request to http://localhost:5000/graphql with the following body

{
	person (id:1) {
		name
		email
		friends{
			name
		}
	}
}
