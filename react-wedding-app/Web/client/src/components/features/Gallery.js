import React, { useEffect, useState } from "react";
import styled from "styled-components";
import { Grid } from "../../assets/scripts/gridrules";
import breakpoint from "../../assets/scripts/breakpoints";
import { connect } from "react-redux";
import { fetchImages, deleteImage } from "../../actions/imageActions";
import { Container } from "react-bootstrap";
import ReactPaginate from 'react-paginate';

const Gallery = (props) => {
  const [images, setImages] = useState([]);
 
  /* Gets notifications from DB */
  useEffect(() => {
    props.dispatch(fetchImages());
  }, []);

  useEffect(() => {
    setImages(props.items);
  }, [props.items]);

  const handleDelete = (id, index) => {
    props.dispatch(deleteImage(id, index));
  };

  /* Pagination */
  const [pageNumber, setPageNumber] = useState(0)

  const imagesPerPage = 8
  const pagesVisited = pageNumber * imagesPerPage;

  const displayImages = images.slice(pagesVisited, pagesVisited + imagesPerPage);


  const pageCount = Math.ceil(images.length/imagesPerPage);
  
  const changePage = ({selected}) => {
    setPageNumber(selected);
  }

  
  return (
    <Container>
      <StyledContainer>
        <Grid>
          <StyledRow>
            {displayImages &&
              displayImages.map((img, index) => (
                <StyledCol key={index}>
                  <StyledImage
                    src={img.url}
                    key={index}
                    onDoubleClick={handleDelete.bind(this, img.id, index)}
                  />
                </StyledCol>
              ))}

              
          </StyledRow>
        </Grid>
        <ReactPaginate
                previousLabel={"Previous"}
                nextLabel={"Next"}
                pageCount={pageCount}
                onPageChange={changePage}
                containerClassName={"paginationBtns"}
                previousLinkClassName={"previousBtn"}
                nextLinkClassName={'nextBtn'}
                disabledClassName={'paginationDisabled'}
                activeClassName={'paginationActive'}
              />
      </StyledContainer>
    </Container>
  );
};

function mapStateToProps(state) {
  const { items } = state.images;
  return {
    items,
  };
}

export default connect(mapStateToProps)(Gallery);

const StyledContainer = styled.div`
  background: white;
  padding-top: 2vh;
  padding-bottom: 5vh;
  @media only screen and ${breakpoint.device.sm} {
  }
`;

const StyledImage = styled.img`
  margin-top: 8px;
  vertical-align: middle;
  width: 100%;
  height: auto;
`;

const StyledRow = styled.div`
  display: -ms-flexbox; /* IE10 */
  display: flex;
  -ms-flex-wrap: wrap; /* IE10 */
  flex-wrap: wrap;
  padding: 0 4px;
`;

const StyledCol = styled.div`
  -ms-flex: 25%; /* IE10 */
  flex: 25%;
  max-width: 100%;
  padding: 0 4px;

  @media screen and (max-width: 800px) {
    -ms-flex: 50%;
    flex: 50%;
    max-width: 50%;
  }
  @media screen and (max-width: 600px) {
    -ms-flex: 100%;
    flex: 100%;
    max-width: 100%;
  }
`;
