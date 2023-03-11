import React from 'react';
import classes from './Cage.module.css'

const Cage = (props) => {
    const x = props.number % 8;
    const y = Math.floor(props.number / 8);
    const black = (x + y) % 2 === 1;
    const color = black ? classes.black : classes.white;

    return (
      <div key={props.number.toString()}
        className={classes.square + " " + color}
        style={{
          transform : `translate(${x * 100}%, ${y * 100}%)`
        }}
      />
    );
};

export default Cage;