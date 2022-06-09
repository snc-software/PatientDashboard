import {render, screen } from '@testing-library/react';
import Busy from "../Busy";

describe("BusyTests", () => {

    it('should render a backdrop', () => {
        render(<Busy />);
        var backdrop = screen.getByTestId('backdrop');
        expect(backdrop).toBeInTheDocument();
    })

    it('should render a spinner', () => {
        render(<Busy />);
        var spinner = screen.getByTestId('spinner');
        expect(spinner).toBeInTheDocument();
    })

    it('should render loading text', () => {
        render(<Busy />);
        var loadingText = screen.getByText(/Loading.../i);
        expect(loadingText).toBeInTheDocument();
    })
})