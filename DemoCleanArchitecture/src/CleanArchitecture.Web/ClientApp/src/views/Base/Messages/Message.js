import React, { useState, useContext, useEffect } from 'react';
import { Message as BaseMessage } from 'semantic-ui-react';

const getList = (messages, message) => {
  let list = [];

  if (message && message.length !== 0)
    list.push(message);
  if (messages)
    list = list.concat(messages);
  console.log("Message: " + message);
  console.log("Messages: " + messages);
  console.log("list: " + list);
  return list;
};

export default function Message(props) {
  const [list, setMessageList] = useState([]);

  useEffect(() => {
    setMessageList(getList(props.messages, props.message));
  }, [props.messages, props.message]);

  if (!list || list.length === 0)
    return null;

  return (
    <BaseMessage list={list} error={props.error} info={props.info} warning={props.warning} />
  );
}
