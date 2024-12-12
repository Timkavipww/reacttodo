import { Card, Heading, Text } from '@chakra-ui/react';
import moment from 'moment';

export default function Note({ title, description, createdAt }) {
  return (
    <Card.Root>
      <Card.Header bg="gray.300">
        <Heading size="md">{title}</Heading>
      </Card.Header>
      <Card.Body bg="gray.300">
        <Text>{description}</Text>
      </Card.Body>
      <Card.Footer bg="gray.300">
        {moment(createdAt).format('HH:mm DD MMMM')}
      </Card.Footer>
    </Card.Root>
  );
}
